using DevExpress.XtraEditors;
using ExtendMethods.LogManage;
//using LogManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtendMethods
{
    public delegate void ComplicateEventHandler();
    /// <summary>
    /// 控件事件的管理类
    /// </summary>
    public static class ControlEventManager
    {
        private static Dictionary<Control, List<ComplexEvent>> eventDictionary = new Dictionary<Control, List<ComplexEvent>>();
        public static void AddTextEditValueChange(TextEdit editor, ComplicateEventHandler e)
        {
            if (eventDictionary.ContainsKey(editor))
            {
                List<ComplexEvent> eventList = eventDictionary[editor];
                ComplexEvent valueChange = null;
                foreach (ComplexEvent ce in eventList)
                {
                    if (ce is TextEditValueChange)
                    {
                        valueChange = ce; 
                        break;
                    }
                }
                if (valueChange != null)
                {
                    valueChange.AddEventListener(e);
                }
                else
                {
                    ComplexEvent editorChange = new TextEditValueChange(editor);
                    editorChange.AddEventListener(e);
                    eventList.Add(editorChange);
                }
            }
        }

        public static void RemoveTextEditValueChange(TextEdit editor, ComplicateEventHandler e)
        {
            if (eventDictionary.ContainsKey(editor))
            {
                List<ComplexEvent> eventList = eventDictionary[editor];
                ComplexEvent valueChange = null;
                foreach (ComplexEvent ce in eventList)
                {
                    if (ce is TextEditValueChange)
                    {
                        valueChange = ce;
                        break;
                    }
                }
                if (valueChange != null)
                {
                    if (valueChange.HasRegisteEventNumber() <= 0)
                    {
                        eventList.Remove(valueChange);
                    }
                    else if (valueChange.HasRegisteEventNumber() == 1)
                    {
                        valueChange.RemoveEventListener(e);
                        eventList.Remove(valueChange);

                    }
                }
            }
        }

        /// <summary>
        /// 清除缓存，如果控件的值被代码修改，不清楚缓存，缓存不会被更新
        /// 重新输入值与上次输入值相同（即与缓存_dirtyData的值相同）
        /// 按Enter和拾取焦点不会触发ValueChanged事件
        /// </summary>
        /// <param name="editor"></param>
        public static void RemoveCache(TextEdit editor)
        {
            if (!eventDictionary.ContainsKey(editor))
                return;
            List<ComplexEvent> eventList = eventDictionary[editor];
            if (eventList == null || eventList.Count < 1)
                return;
            foreach(TextEditValueChange ce in eventList)
            {
                if (ce == null)
                    continue;
                ce.RemoveCache();
            }
        }
    }
    public interface ComplexEvent
    {
        void AddEventListener(ComplicateEventHandler e);
        void RemoveEventListener(ComplicateEventHandler e);
        int HasRegisteEventNumber();
    }

    public class TextEditValueChange : ComplexEvent
    {
        private ComplicateEventHandler valueChanged;
        /// <summary>
        /// 输入框
        /// </summary>
        private TextEdit _textEdit = null;
        /// <summary>
        /// 上一次的数据，留着作对比
        /// </summary>
        private string _dirtyData;
        /// <summary>
        /// 是否修改过输入框的内容
        /// </summary>
        private bool _hasChange = false;
        public TextEditValueChange(TextEdit textEdit)
        {
            if (textEdit != null)
            {
                _textEdit = textEdit;
                _dirtyData = textEdit.Text;
                textEdit.Leave += OnLeave;
                textEdit.PreviewKeyDown += OnPreviewKeyDown;
                textEdit.EditValueChanging += StartChange;
            }
        }

        private void StartChange(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            this._hasChange = true;
        }

        private void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextEdit textEdit = sender as TextEdit;
                if (textEdit == null)
                    return;
                if (!textEdit.DoValidate())
                    return;
                InvokeValueChangeEvent();
            }
        }

        private void OnLeave(object sender, EventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            if (textEdit == null)
                return;
            if (!textEdit.DoValidate())
                return;
            InvokeValueChangeEvent();
        }

        private void InvokeValueChangeEvent()
        {
            if (_hasChange)
            {
                _hasChange = false;
                string currentData = _textEdit.Text;
                if (currentData != _dirtyData)
                {
                    _dirtyData = currentData;
                    if (valueChanged != null)
                    {
                        try
                        {
                            valueChanged();
                        }
                        catch (Exception ex)
                        {
                            SystemLog.Log(ex);
                        }
                    }
                }
            }
        }
        public void AddEventListener(ComplicateEventHandler e)
        {
            valueChanged += e;
        }
        public void RemoveEventListener(ComplicateEventHandler e)
        {
            valueChanged -= e;
        }
        public int HasRegisteEventNumber()
        {
            Delegate[] allEvent = valueChanged.GetInvocationList();
            if (allEvent != null && allEvent.Length > 0)
            {
                return allEvent.Length;
            }
            return 0;
        }
        public void RemoveCache()
        {
            _dirtyData = string.Empty;
        }
    }
}
