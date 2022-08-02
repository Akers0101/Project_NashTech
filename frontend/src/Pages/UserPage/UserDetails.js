import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Typography from "@mui/material/Typography";
import axios from "axios";
import Popupclose from "../../Components/Modal/Popupclose";
import { makeStyles } from "@mui/styles";
import moment from "moment";
const styles = makeStyles({
  wrapper: {
    width: "65%",
    margin: "auto",
    textAlign: "center",
  },
  bigSpace: {
    marginTop: "5rem",
  },
  littleSpace: {
    marginTop: "2.5rem",
    marginBottom: "2.5rem",
  },
});
export default function UserDetails() {
 
  const token = localStorage.getItem("token");
  const [openPopup, setOpenPopup] = useState(true);
  const { id } = useParams();
  useEffect(() => {
    axios({
      method: 'GET',
      url: `${process.env.REACT_APP_Backend_URI}/Users/detail/${id}`,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
    },
  }
    )
    .then(function (response) {
      setItem(response.data);
    }, [])
    .catch((error) => {
      console.log(error);
    });
  // eslint-disable-next-line react-hooks/exhaustive-deps
  },[]);
    
  const [item, setItem] = useState({});

  

  const classes = styles();
  return (
    <div>
      <div className={classes.wrapper}>
        <Popupclose  title="User Detail"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}>
            
          
          <Typography
            variant="h6"
            align="left" sx={{ margin: 1}}
          >
            Staff Code: <span></span>
            {item.staffCode}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 1}}
          >
            User Name: <span></span>
            {item.userName}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 1}}
          >
            FullName: <span></span>
            {item.firstName} {item.lastName}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 1}}
          >
            Gender: <span></span>
            {item.gender}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 1}}
          >
            Date of Birth: <span></span>
            {moment(item.dateOfBirth).format('DD/MM/YYYY')}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 1}}
          >
            Location: <span></span>
            {item.location}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 1}}
          >
            Type: <span></span>
            {item.role}
          </Typography>
         
        </Popupclose>
      </div>
    </div>
  );
}
