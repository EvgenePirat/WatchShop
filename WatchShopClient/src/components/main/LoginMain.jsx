import React from 'react'
import BreadcrumbSection from '../breadcrumb/BreadcrumbSection'
import AuthenticationSectionLogin from '../authentication/AuthenticationSectionLogin'

const LoginMain = () => {
  return (
    <>
        <BreadcrumbSection title={"Login"} current={"Login"}/>
        <AuthenticationSectionLogin/>
    </>
  )
}

export default LoginMain