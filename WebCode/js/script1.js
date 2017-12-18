	//封装一个代替getElementById（）的方法
	function byId(id){
		return typeof(id)==="string"?document.getElementById(id):id;
	}
	//全局变量
	var index=0,
	timer=null,
	pics=byId("banner").getElementsByTagName("div"),
	dots=byId("dots").getElementsByTagName("span"),
	prev=byId("prev"),
	next=byId("next"),
	size = pics.length,
	len=pics.length,
	menuItems = byId("menu-content").getElementsByTagName("div"),
    subMenu = byId("sub-menu"),
    subItems = subMenu.getElementsByClassName("inner-box");


// 清除定时器,停止自动播放
function stopAutoPlay(){
	if(timer){
       clearInterval(timer);
	}
}
	//图片自动轮播
function startAutoPlay(){
   timer = setInterval(function(){
       index++;
       if(index >= size){
          index = 0;
       }
       changeImg();
   },3000)
}



	function slideImg(){
		var main=byId("main");
		var banner = byId("banner");
		var menuContent = byId("menu-content");
		//滑过清楚定时器，离开继续
		main.onmouseover=function(){
	    //清除定时器
	    // if(timer)
	    // 	clearInterval(timer);
	    stopAutoPlay();
    
	}
	main.onmouseout=function(){
		// timer=setInterval(function(){
		// 	index++;
		// 	if(index>=len){
		// 		index=0;
		// 	}
		// 		//切换图片
		// 		changeImg();
		// 	},3000);
		startAutoPlay();
	}
	main.onmouseout();
	//点击圆点切换图片
	 for(var d=0;d<len;d++){
	 	dots[d].id=d;
	 	dots[d].onclick=function(){
	 		index=this.id;
	 		//this.className="active"
	 		changeImg();
	 	}
	 }
	 next.onclick=function(){
	 	index++;
	 	if(index>=len)
	 	{
	 		index=0;
	 	}
	 	changeImg();
	 }
	prev.onclick=function(){
		index--;
		if(index<0)index=len-1;
		changeImg();
	}

	    // 菜单
	    for(var m=0,mlen=menuItems.length;m<mlen;m++){
	        menuItems[m].setAttribute("data-index",m);
	        menuItems[m].onmouseover = function(){
	            subMenu.className = "sub-menu";
	            var idx = this.getAttribute("data-index");
	            for(var j=0,jlen=subItems.length;j<jlen;j++){
	               subItems[j].style.display = 'none';
	               menuItems[j].style.background = "none";
	            }
	            subItems[idx].style.display = "block";
	            menuItems[idx].style.background = "rgba(0,0,0,0.1)";
	        }
	    }

	    subMenu.onmouseover = function(){
        this.className = "sub-menu";
    }

    subMenu.onmouseout = function(){
        this.className = "sub-menu hide";
    }

    banner.onmouseout = function(){
        subMenu.className = "sub-menu hide";
    }

    menuContent.onmouseout = function(){
        subMenu.className = "sub-menu hide";
    }
	}


	//切换图片
	function changeImg(){
		for(var i=0;i<len;i++){
			pics[i].style.display="none";
			dots[i].className="";
		}
		pics[index].style.display='block';
		dots[index].className="active"
	}
	slideImg();
