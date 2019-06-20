// Developed:  Kazmi 5:10 PM 4/12/2006
function showCalendar(ObjTxt)
  {
   //alert(ObjTxt);
   var winRetValue=window.showModalDialog("calendar.htm","","dialogHeight: 235px; dialogWidth: 272px;  center: Yes; help: No; resizable: No; status: No;titlebar:No");
   //alert(winRetValue);
   if (winRetValue != "0") 
    ObjTxt.value = winRetValue;
  }