import React, { useRef } from "react";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation, Pagination } from "swiper/modules";

const TestimonialSlider = () => {
  const swiperRef = useRef(null);

  const goNext = () => {
    if (swiperRef.current && swiperRef.current.swiper) {
      swiperRef.current.swiper.slideNext();
    }
  };

  const goPrev = () => {
    if (swiperRef.current && swiperRef.current.swiper) {
      swiperRef.current.swiper.slidePrev();
    }
  };
  return (
    <section className="fz-2-testimonial-section">
      <div className="container">
        <div className="fz-2-section-heading">
          <h2 className="fz-section-title">Reviews From Clients</h2>
        </div>

        <div className="row justify-content-center">
          <div className="col-lg-6 col-md-7 col-9 col-xxs-12 position-relative">
            <div className="fz-testimonial-slider-nav">
              <button
                type="button"
                role="presentation"
                className="owl-prev"
                onClick={goPrev}
              >
                <i className="fa-solid fa-angle-left"></i>
              </button>
              <button
                type="button"
                role="presentation"
                className="owl-next"
                onClick={goNext}
              >
                <i className="fa-solid fa-angle-right"></i>
              </button>
            </div>
            <Swiper
              slidesPerView={1}
              navigation={{
                prevEl: ".owl-prev",
                nextEl: ".owl-next",
              }}
              pagination={{
                el: ".fz-testimonial-slider-dots",
                clickable: true,
                bulletClass: "owl-dot",
                bulletActiveClass: "active",
              }}
              modules={[Navigation, Pagination]}
              className="fz-testimonial-slider-container owl-carousel"
            >
              <SwiperSlide className="fz-single-testimony">
                <span className="quote-icon">
                  <i className="fa-solid fa-quote-right"></i>
                </span>
                <p className="fz-single-testimony-txt">
                I just received my new watch from your store and I couldn't be happier with my purchase. The watch arrived promptly and was packaged securely, ensuring it arrived in pristine condition. From the moment I opened the box, I was impressed by the elegant design and craftsmanship of the timepiece. It's clear that a lot of thought and care went into creating this watch, as every detail is meticulously crafted. Not only does it elevate my style, but it also serves as a reliable companion throughout my busy day. Thank you for providing such a wonderful product and excellent customer service. I'll definitely be a repeat customer!
                </p>

                <div className="fz-reviewer">
                  <div className="fz-reviewer-info">
                    <div className="fz-rating">
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                    </div>
                    <h6 className="fz-reviewer-name">Marisa Tomei</h6>
                  </div>
                </div>
              </SwiperSlide>
              <SwiperSlide className="fz-single-testimony">
                <span className="quote-icon">
                  <i className="fa-solid fa-quote-right"></i>
                </span>
                <p className="fz-single-testimony-txt">
                The watch not only looks fantastic on my wrist but also feels incredibly comfortable to wear throughout the day. The attention to detail in its design is evident, from the intricate dial to the sturdy yet stylish strap. What's more, the functionality of the watch is impeccable, providing me with accurate timekeeping and convenient features that make my daily routine a breeze. Thank you for offering such a high-quality product that exceeds my expectations in every way!
                </p>

                <div className="fz-reviewer">
                  <div className="fz-reviewer-info">
                    <div className="fz-rating">
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-regular fa-star"></i>
                    </div>
                    <h6 className="fz-reviewer-name">Kilma Ani</h6>
                  </div>
                </div>
              </SwiperSlide>
              <SwiperSlide className="fz-single-testimony">
                <span className="quote-icon">
                  <i className="fa-solid fa-quote-right"></i>
                </span>
                <p className="fz-single-testimony-txt">
                I recently bought a watch from your store and I must say, it exceeded my expectations in every aspect. The quality of the timepiece is outstanding, reflecting the craftsmanship and attention to detail put into its design. Not only does it look stylish and elegant, but it also feels durable and well-made. The customer service provided by your team was exceptional, guiding me through the selection process and ensuring I made the right choice. I've received numerous compliments on my new watch, and I couldn't be happier with my purchase. Thank you for providing such a wonderful product and shopping experience. I will definitely be recommending your store to friends and family!
                </p>

                <div className="fz-reviewer">

                  <div className="fz-reviewer-info">
                    <div className="fz-rating">
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                      <i className="fa-solid fa-star"></i>
                    </div>
                    <h6 className="fz-reviewer-name">Daniel Liv</h6>
                  </div>
                </div>
              </SwiperSlide>
            </Swiper>
            <div className="fz-testimonial-slider-dots">
              <button role="button" className="owl-dot">
                <span></span>
              </button>
              <button role="button" className="owl-dot">
                <span></span>
              </button>
              <button role="button" className="owl-dot">
                <span></span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default TestimonialSlider;
