import React from 'react';
import Datatable from './Datatable';

import FirstLogin from '../LoginPage/FirstLogin';
 import Login from '../LoginPage/LoginPage';
function AssetPage() {
    return ( <div>
         <div className="header-component-text">
        <p>Asset List</p>
        </div>
            {localStorage.getItem("token") ?

            (localStorage.getItem("isFirstLogin")==="True"?(<FirstLogin />):( <Datatable />)
            )
            :(<><Login/></>)
            }

    </div> );
}

export default AssetPage;