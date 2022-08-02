import React from 'react'
import { Dialog, DialogTitle, DialogContent, Typography } from '@mui/material';
import ActionButton from '../ActionButton/ActionButton';
import { makeStyles } from "@mui/styles";
import CloseIcon from '@mui/icons-material/Close';
const useStyles = makeStyles(theme => ({
    dialogWrapper: {
        padding: theme.spacing(2),
        // position: 'absolute',
        top: theme.spacing(5)
    },
    dialogTitle: {
        paddingRight: '0px'
    }
}))

export default function PopupForError(props) {

    const { setOpenErrorPopup,title, children, openErrorPopup } = props;
    const classes = useStyles();

    return (
        <Dialog open={openErrorPopup} maxWidth="md" classes={{ paper: classes.dialogWrapper }}>
            <DialogTitle className={classes.dialogTitle}>
                <div style={{ display: 'flex' }}>
                    <Typography variant="h6" component="div" style={{ flexGrow: 1 , color: '#cf2338'}}>
                        {title}
                    </Typography>
                    <ActionButton
                        color="secondary"
                        onClick={()=>{
                            setOpenErrorPopup(false);
                           
                            }}>
                        <CloseIcon />
                    </ActionButton>
                </div>
            </DialogTitle>
            <DialogContent dividers>
                {children}
            </DialogContent>
        </Dialog>
    )
}