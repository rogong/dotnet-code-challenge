import { Box, Grid, List, ListItem, Button, Paper, Typography, Link } from '@mui/material';
import banner from '../../images/dpr2.png';

const Home = () => {
  return (
    <>
    <Box sx={{bgcolor: '#74b971', width: '1200', pt: '50'}}>
      <Grid container sx={{ pl: 15, pr:15, pt: 15}}>

      <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
       <Typography sx={{color: '#fff'}}>
       DPR as a regulatory authority, is concerned and seek to compensate car 
       
    
   
       owners and fuelling station across the Nation. </Typography>

       <Typography variant='h6' sx={{color: 'primary', pb:'2'}}>My car was affacted 
       
         </Typography>
        <Link href='/carownerinfo-apply'>
        <Button   variant="contained"
                  color="success">Apply here</Button>
        </Link>

            <Typography variant='h6' sx={{color: '#fff', pb:'2' }}>My fuelling station was affacted 
            
              </Typography>

              <Link href='/fuellinstationinfo-apply'>
              <Button   variant="contained" 
                  color="primary">Apply here</Button>
                   </Link>
       </Grid>

       <Grid item xs={12} sm={6} sx={{  pb: 2}}>
<img src={banner} alt='' width={300} />
       </Grid>
     </Grid>
  
      
    

    </Box>
    </>
  );
};

export default Home;
