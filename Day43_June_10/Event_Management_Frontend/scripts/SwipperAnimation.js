var swiperEl = document.querySelector('.swiper-container');
var mySwiper = new Swiper (swiperEl, {
//   loop: true,
  spaceBetween: 50,
  slidesPerView: 'auto',
  loopedSlides: 0,
  loopAdditionalSlides: 6,
//   centeredSlides: true,
  
  navigation: {
    nextEl: '.swiper-button-next',
    prevEl: '.swiper-button-prev',
  },    
//   initialSlide: Math.floor(document.querySelectorAll('.swiper-slide').length / 2),

})


const nextBtn = swiperEl.querySelector('.swiper-button-next')
const prevBtn = swiperEl.querySelector('.swiper-button-prev')

nextBtn.addEventListener('click', (e)=>{
  e.preventDefault()
  mySwiper.slideToLoop(mySwiper.realIndex + 1, 1000);
})
prevBtn.addEventListener('click', (e)=>{
  e.preventDefault()
  mySwiper.slideToLoop(mySwiper.realIndex - 1, 1000);
})