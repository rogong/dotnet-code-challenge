import * as yup from 'yup';

export const validationSchema = yup.object({
    firstName: yup.string().required(),
    lastName: yup.string().required(),
    state: yup.string().required(),
    city: yup.string().required(),
    lga: yup.string().required(),
    address: yup.string().required(),
    vehicleModel: yup.string().required(),
    vehicleMaker: yup.string().required(),
    purchaseReceiptUrl: yup.mixed().when('pictureUrl', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    }),
    vehicleDocUrl: yup.mixed().when('pictureUrl', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    })
})