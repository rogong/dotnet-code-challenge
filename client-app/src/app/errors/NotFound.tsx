import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { useHistory } from "react-router-dom";



export default function NotFound() {
    const history = useHistory();
  
    return (
     <Container component={Paper} sx={{height: 400}}>
         <Typography gutterBottom variant='h3'> Oops - we could not find your keywords!</Typography>
       <Divider />
       <Button onClick={() => history.push('/feed')}>Go back to the page</Button>
     </Container>
    )
}
