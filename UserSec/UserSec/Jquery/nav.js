

$(document).ready(function () {

    $('a.level1').after('<div class="divider"><span class="left"></span><span class="right"></span></div>');

    //Drop Down Menu
    /* $('.nav .nav-li').hover(
    function () {
    //show its submenu
    $('ul', this).slideDown(100);

    },
    function () {
    //hide its submenu
    $('ul', this).slideUp(100);
    }
    );*/

    $('.notification').click(
        function () {
            $(this).slideUp();
        });


});
	
	/*
    function disableRightClick(e)
    
    {
    
      var message = "Right click disabled";
    
      
    
      if(!document.rightClickDisabled) // initialize
    
      {
    
        if(document.layers) 
    
        {
    
          document.captureEvents(Event.MOUSEDOWN);
    
          document.onmousedown = disableRightClick;
    
        }
    
        else document.oncontextmenu = disableRightClick;
    
        return document.rightClickDisabled = true;
    
      }
    
      if(document.layers || (document.getElementById && !document.all))
    
      {
    
        if (e.which==2||e.which==3)
    
        {
    
          //alert(message);
    
          return false;
    
        }
    
      }
    
      else
    
      {
    
        //alert(message);
    
        return false;
    
      }
    
    }
    
    disableRightClick();
    */