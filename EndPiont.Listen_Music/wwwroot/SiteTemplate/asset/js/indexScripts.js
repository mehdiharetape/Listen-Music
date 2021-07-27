//--------------Handler(index)----------------------------
function Handler(index) {
    const Legions = document.querySelectorAll(".btn-item-side");
    const groups = document.querySelectorAll(".legion-group");
    
    Legions[index].addEventListener('mouseover', () => {
        groups[index].style.display = "inline";
        for (var i = 0; i < Legions.length; i++) {
            if (i == index) {
                continue;
            }
            groups[i].style.display = "none";
        }
    });

    groups[index].addEventListener('mouseleave', () => {
        groups[index].style.display = "none";
    });
}
//----------------------handlerCall(index)---------------------
function handlerCaller(index){
    for(var i = 0; i < index; i++){
        Handler(i);
    }
}
//----------------------call handlerCaller(index)---------------
handlerCaller(2);
//--------------------------------------------------------------
var usernameButton = document.getElementById("username-button");
var exprof = document.getElementById("exit-prof-container");
usernameButton.addEventListener('click', () => {
    exprof.style.display = 'inline-block';
    exprof.addEventListener('mouseleave', ()=>{
        exprof.style.display = 'none';
    });
});