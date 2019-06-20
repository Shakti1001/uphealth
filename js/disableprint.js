// JScript File

function keyTrap(e)

	{

if(keycode == 116)
{
event.keyCode = 0;
event.returnValue = false;
return false;
}

if (event.keyCode == 8) 
{
      return false;
    } 
		// Netscape uses e, IE window.event

		var eventObj = (e)?e:window.event;

		var keyPressed = (e)?e.which:window.event.keyCode;	

		var ctrlPressed = (e)?(e.ctrlKey):window.event.ctrlKey;



		if (ctrlPressed)

		{

			switch (keyPressed)

			{

				case 80:	// CTRL-P.

					window.event.keyCode = 0;

					return false;

			}

		}

	}

	if(document.layers)

	{		

		//NS4+

		document.captureEvents(Event.ONKEYDOWN);

	}

	document.onkeydown=keyTrap;






// JScript File

function checkShortcut()
{
          if(event.keyCode==8 || event.keyCode==13)
         {
               return false;
         }
}

// JScript File

// JScript File

function keyTrap(e)

	{


if (event.keyCode == 8) 
{
      return false;
    } 
    var keycode =(window.event) ? event.keyCode : e.keyCode;

if(keycode == 116)
{
event.keyCode = 0;
event.returnValue = false;
return false;
}
		// Netscape uses e, IE window.event

		var eventObj = (e)?e:window.event;

		var keyPressed = (e)?e.which:window.event.keyCode;	

		var ctrlPressed = (e)?(e.ctrlKey):window.event.ctrlKey;



		if (ctrlPressed)

		{

			switch (keyPressed)

			{

				case 80:	// CTRL-P.

					window.event.keyCode = 0;

					return false;

			}

		}

	}

	if(document.layers)

	{		

		//NS4+

		document.captureEvents(Event.ONKEYDOWN);

	}

	document.onkeydown=keyTrap;


window.history.forward(1);


