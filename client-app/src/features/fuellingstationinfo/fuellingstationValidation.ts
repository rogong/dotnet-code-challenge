import * as yup from 'yup';

export const validationSchema = yup.object({
    ownersName: yup.string().required(),
    state: yup.string().required(),
    lga: yup.string().required(),
    city: yup.string().required(),
    address: yup.string().required(),
    firstName: yup.string().required(),
    businessDocUrl: yup.mixed().when('pictureUrl', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    }),
    depotReceiptUrl: yup.mixed().when('pictureUrl', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    })
})