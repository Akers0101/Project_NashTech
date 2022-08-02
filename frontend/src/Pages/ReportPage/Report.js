import React from 'react';
import FirstLogin from '../LoginPage/FirstLogin';
import Login from '../LoginPage/LoginPage';
import ReportDatatable from './ReportDatatable';

const Report = () => {
    return (
        <div>
        <div className="header-component-text">
       <p>Report</p>
       </div>
           {localStorage.getItem("token") ?

           (localStorage.getItem("isFirstLogin")==="True"?(<FirstLogin />):( <ReportDatatable />)
           )
           :(<><Login/></>)
           }

   </div>
    );
}

export default Report;
