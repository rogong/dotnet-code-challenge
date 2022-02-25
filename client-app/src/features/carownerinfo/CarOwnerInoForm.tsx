import { Typography, Grid, Paper, Box, Button } from '@mui/material';
import { useEffect, useState } from 'react';
import { FieldValues, useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';

import AppDropzone from '../../app/components/AppDropzone';
import AppTextInput from '../../app/components/AppTextInput';
import AppSelectList from '../../app/components/AppSelectList';
import { OwnersInfo } from '../../app/models/ownersinfo';

import { validationSchema } from './carownerValidation';

import agent from '../../app/api/agent';

import { LoadingButton } from '@mui/lab';
import { toast } from 'react-toastify';

interface Props {
  ownersInfo?: OwnersInfo;
}

export default function CarOwnerInoForm() {
  const [successpage, setSuccessPage] = useState(false);
  const [showForm, setShowForm] = useState(true);

  const {
    control,
    handleSubmit,
    watch,
    formState: { isDirty, isSubmitting },
  } = useForm({
    mode: 'all',
    resolver: yupResolver<any>(validationSchema),
  });

  const watchFile = watch('vehicleDocUrl', null);

  const watchFile2 = watch('purchaseReceiptUrl', null);

  // async function handleSubmitData(data: FieldValues) {
  //  await agent.VehicleOwnersInfo.create(data)
  //   .then(() => {
  //     toast.success('Application Submitted Successfully');
     
  // })
  // .catch(error => toast.error(error));
  // }

  const state: any = ['Lagos', 'Oyo'];

  return (
    <>
   {successpage && <Box component={Paper} sx={{ p: 10 }}>
      <Typography variant='h3' sx={{color: 'green'}}>Thank you, we shall contact you soon!</Typography>
    </Box> }
    {showForm &&
      <Box component={Paper} sx={{ p: 4 }}>
        <Grid container spacing={1} sx={{ mt: 8 }}>
          <Grid item xs={2}></Grid>

          <Grid item xs={8}>
            <Typography variant="h4" sx={{ mb: 4 }}>
              Owner's Details
            </Typography>

            <form 
            onSubmit={handleSubmit( (data: FieldValues) => 
              agent.VehicleOwnersInfo.create(data)
              .then(() => {
                toast.success('Application submitted successfully!');
                setSuccessPage(true)
                setShowForm(false)
              })
              .catch(error => toast.error(error))
             
            )}
          >
              <Grid container sx={{ pb: 2 }}>
                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppTextInput
                    control={control}
                    name="firstName"
                    label="First name"
                  />
                </Grid>
                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppTextInput
                    control={control}
                    name="lastName"
                    label="Last name"
                  />
                </Grid>
              </Grid>

              <Grid container sx={{ pb: 2 }}>
                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppSelectList
                    items={state}
                    control={control}
                    name="state"
                    label="State"
                  />
                </Grid>

                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppTextInput control={control} name="city" label="City" />
                </Grid>
              </Grid>

              <Grid container sx={{ pb: 2 }}>
                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppTextInput
                    control={control}
                    name="lga"
                    label="Local Govn."
                  />
                </Grid>

                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppTextInput
                    control={control}
                    name="address"
                    label="Home Address"
                  />
                </Grid>
              </Grid>

              <Grid container sx={{ pb: 2 }}>
                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppTextInput
                    control={control}
                    name="vehicleMaker"
                    label="Vehicle Maker"
                  />
                </Grid>

                <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                  <AppTextInput
                    control={control}
                    name="vehicleModel"
                    label="Vehicle Model"
                  />
                </Grid>
              </Grid>

              <Grid item xs={12}>
                <Typography>Upload Proof of Car Ownership</Typography>
                <Box
                  display="flex"
                  justifyContent="space-between"
                  alignItems="center"
                >
                  <Grid container sx={{ pb: 2 }}>
                    <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                      <AppDropzone control={control} name="vehicleDocUrl" />
                    </Grid>
                    <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                      {watchFile ? (
                        <img
                          src={watchFile.preview}
                          alt="preview"
                          style={{ maxHeight: 200, maxWidth: 200 }}
                        />
                      ) : (
                        <div />
                      )}
                    </Grid>
                  </Grid>
                </Box>

                <Typography>Upload Fuel Purchased Receipt</Typography>
                <Box
                  display="flex"
                  justifyContent="space-between"
                  alignItems="center"
                >
                  <Grid container sx={{ pb: 2 }}>
                    <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                      <AppDropzone
                        control={control}
                        name="purchaseReceiptUrl"
                      />
                    </Grid>

                    <Grid item xs={12} sm={6} sx={{ pr: 2, pb: 2 }}>
                      {watchFile2 ? (
                        <img
                          src={watchFile2.preview}
                          alt="preview"
                          style={{ maxHeight: 200, maxWidth: 200 }}
                        />
                      ) : (
                        <div />
                      )}
                    </Grid>
                  </Grid>
                </Box>
              </Grid>

              <Box display="flex" justifyContent="space-between" sx={{ mt: 3 }}>
                <LoadingButton
                  loading={isSubmitting}
                  type="submit"
                  variant="contained"
                  color="success"
                >
                  Submit
                </LoadingButton>
              </Box>
            </form>
            <Grid item xs={2}></Grid>
          </Grid>
        </Grid>
      </Box>
      }
  
    </>
  );
}
