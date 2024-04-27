import React from 'react'
import BreadcrumbSection from '../breadcrumb/BreadcrumbSection'
import StoreSection from '../store/StoreSection'


const AboutMain = () => (
    <>
        <BreadcrumbSection title={"About Us"} current={"About"} />
        <StoreSection/>
    </>
)

export default AboutMain