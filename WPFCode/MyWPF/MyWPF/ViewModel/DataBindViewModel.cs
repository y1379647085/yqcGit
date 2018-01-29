﻿using MyWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCommon;

namespace MyWPF.ViewModel
{
    class DataBindViewModel : NotifyObject
    {
        private double _doubleValue;
        /// <summary>
        /// Double类型的测试数据
        /// </summary>
        public double DoubleValue
        {
            get { return _doubleValue; }
            set
            {
                if (_doubleValue != value)
                {
                    _doubleValue = value;
                    RaisePropertyChanged("DoubleValue");
                }
            }
        }
        private TestData _selectedData;
        /// <summary>
        /// 列表中选中行的对象
        /// </summary>
        public TestData SelectedData
        {
            get { return _selectedData; }
            set
            {
                if (_selectedData != value)
                {
                    _selectedData = value;
                    RaisePropertyChanged("SelectedData");
                }
            }
        }

        private List<TestData> _testDataList;
        /// <summary>
        /// 列表类数据
        /// </summary>
        public List<TestData> TestDataList
        {
            get { return _testDataList; }
            set
            {
                if (_testDataList != value)
                {
                    _testDataList = value;
                }
            }
        }
        public DataBindViewModel()
        {
            _doubleValue = 0.5;
            TestDataList = TestData.GetTestData().ToList();
        }


    }
}
