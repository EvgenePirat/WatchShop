import React from 'react'

const GallerySection = () => {
  return (
    <section className="fz-gallery-section fz-1-gallery-section">
            <div className="fz-1-section-heading">
                <h2 className="fz-section-title text-center">@watch_shop.ukraine</h2>
            </div>

            <div className="row g-0 justify-content-center">
                <div className="col-lg-2 col-md-3 col-4">
                    <div className="fz-single-gallery-item">
                        <img src="assets/images/gallery_img_1.jpg" alt="Gallery Image"/>
                        <button className="fz-ig-btn"><i className="fa-brands fa-instagram"></i></button>
                    </div>
                </div>
                <div className="col-lg-2 col-md-3 col-4">
                    <div className="fz-single-gallery-item">
                        <img src="assets/images/gallery_img_2.jpg" alt="Gallery Image"/>
                        <button className="fz-ig-btn"><i className="fa-brands fa-instagram"></i></button>
                    </div>
                </div>
                <div className="col-lg-2 col-md-3 col-4">
                    <div className="fz-single-gallery-item">
                        <img src="assets/images/gallery_img_3.jpg" alt="Gallery Image"/>
                        <button className="fz-ig-btn"><i className="fa-brands fa-instagram"></i></button>
                    </div>
                </div>
                <div className="col-lg-2 col-md-3 col-4">
                    <div className="fz-single-gallery-item">
                        <img src="assets/images/gallery_img_4.jpg" alt="Gallery Image"/>
                        <button className="fz-ig-btn"><i className="fa-brands fa-instagram"></i></button>
                    </div>
                </div>

                <div className="col-lg-2 col-md-3 col-4">
                    <div className="fz-single-gallery-item">
                        <img src="assets/images/gallery_img_5.jpg" alt="Gallery Image"/>
                        <button className="fz-ig-btn"><i className="fa-brands fa-instagram"></i></button>
                    </div>
                </div>
                <div className="col-lg-2 col-md-3 col-4">
                    <div className="fz-single-gallery-item">
                        <img src="assets/images/gallery_img_6.jpg" alt="Gallery Image"/>
                        <button className="fz-ig-btn"><i className="fa-brands fa-instagram"></i></button>
                    </div>
                </div>
            </div>
        </section>
  )
}

export default GallerySection