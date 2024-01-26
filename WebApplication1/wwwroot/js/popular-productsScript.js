let slider = document.querySelector(".slider");
let next = document.querySelector(".pro-next");
let prev = document.querySelector(".pro-prev");
let slide = document.getElementById("slide");
let item = document.querySelectorAll(".item");




products.forEach((item)=>{

slide.insertAdjacentHTML("beforeend",`<a class="item" href="#"><img class="popular--products__image" src="${item.src}"><span class="popular--products__discription">${item.discription}</span><br><br><span class="popular--products__price">${item.price}</span></a>`)

})

    //refer elements by class name
let position=0;
    prev.addEventListener("click", function() {
      //click previos button
      if (position > 0) {
        //avoid slide left beyond the first item
        position -= 1;
        translateX(position); //translate items
      }
    });

    next.addEventListener("click", function() {
      if (position >= 0 && position <= hiddenItems()) {
        //avoid slide right beyond the last item
        position += 1;
        translateX(position); //translate items
      }
    });
  

  function hiddenItems() {
    //get hidden items
    let items =products.length
    if(screen.width>480)
    {

      let visibleItems = slider.offsetWidth / 210;
      return items - Math.ceil(visibleItems);
    }
    else{
      let visibleItems = slider.offsetWidth / 160;
      return items - Math.ceil(visibleItems);
    }
  }

function translateX(position) {
  //translate items
  if(screen.width>480)
  {
  slide.style.left = position * -210 + "px";
  }
  else{
  slide.style.left = position * -160 + "px";

  }
}
 setInterval(function(){

       if (position >= 0 && position <= hiddenItems()) {
       
         position += 1;
         translateX(position); 
 
       }
      
       if(position==Math.floor(products.length/2) && screen.width>480)
       {
       setTimeout(function(){
      
              
                translateX(Math.floor(products.length/2));
               position=0
       },3000)
      
       }
      if(screen.width<=480 && position==products.length-2)
       {
         setTimeout(function(){
         translateX(products.length-2);
        position=0
       },3000)
     }
 },6000)
  


