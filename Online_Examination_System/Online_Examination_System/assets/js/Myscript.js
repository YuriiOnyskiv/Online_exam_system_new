function clickIE() {if (document.all) {return false;}} 
function clickNS(e) {if 
(document.layers||(document.getElementById&&!document.all)) { 
if (e.which==2||e.which==3) {return false;}}} 
if (document.layers) 
{document.captureEvents(Event.MOUSEDOWN);document.onmousedown=clickNS;} 
else{document.onmouseup=clickNS;document.oncontextmenu=clickIE;} 
document.oncontextmenu=new Function("return false"); 


document.onkeydown = function(ev) {
  var a;
   ev = window.event;
   if (typeof ev == "undefined") {
     alert("PLEASE DON'T USE KEYBORD");
          }
       a = ev.keyCode;
        alert("PLEASE DON'T USE KEYBORD");
              return false;
         }
       document.onkeyup = function(ev) {
           var charCode;
        if (typeof ev == "undefined") {
         ev = window.event;
         alert("PLEASE DON'T USE KEYBORD");
           } else {
          alert("PLEASE DON'T USE KEYBORD");
           }
         return false;
       }