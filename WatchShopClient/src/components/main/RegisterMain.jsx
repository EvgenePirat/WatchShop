import React from 'react'
import BreadcrumbSection from '../breadcrumb/BreadcrumbSection'
import AuthenticationSectionRegistr from '../authentication/AuthenticationSectionRegistr'

const RegisterMain = () => {
  return (
    <>
        <BreadcrumbSection title={"Register"} current={"Register"}/>
        <AuthenticationSectionRegistr/>
    </>
  )
}

export default RegisterMain