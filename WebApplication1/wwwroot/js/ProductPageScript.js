let like=document.querySelectorAll(".icon")

like.forEach(function(item) {
    item.addEventListener("click",function(){
    
        if(item.classList.contains("red--icon"))
        {
            item.classList.remove("red--icon")
        }
        else
        {
            item.classList.add("red--icon")
        }
    })
});
