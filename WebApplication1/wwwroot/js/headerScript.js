const SearchBtn=document.querySelector(".navigation__search--icon")
const BarsPhone=document.querySelector(".header__bars--phone")
const CategorysContinerPhone=document.querySelector(".categorys--continer--phone")
const header=document.querySelector('.header')
const imagCover=document.querySelector(".image--cover")
const SearchInp=document.querySelector("#search--inp")
const ExitSearchbar=document.querySelector(".exit--searchbar--phone")
const HomeIcon=document.querySelector(".navigation__home--icon")



SearchBtn.addEventListener("click",function()
{
    if(SearchInp.value!=="")
    {
        SearchInp.value=""
    }
    
})

HomeIcon.addEventListener("click",function()
{
    location.href='file:///C:/Users/Dell/Desktop/Lutos/HomePage.html'
})

////////////////////////////
// let scrollBar=document.querySelector(".scroll--width")

// document.addEventListener("scroll",function(){
//    let yScroll=window.scrollY
//    let documentHeight=document.body.clientHeight
// //console.log(yScroll);
//    let docinnerheight=window.innerHeight
// console.log(document.body.scrollHeight);

//    let scrollPresent=yScroll/(document.body.scrollHeight)
//    let Round=Math.round(scrollPresent*100)
//    scrollBar.style.width=Round+"%"
//    //console.log("Round ",Round)
   
// })