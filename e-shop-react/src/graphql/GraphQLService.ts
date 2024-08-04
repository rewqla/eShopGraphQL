import {
  gql,
  useQuery,
  useMutation,
  ApolloClient,
  InMemoryCache,
} from "@apollo/client";
import { BRAND_FIELDS, TYPE_FIELDS } from "./fragments";
import {
  GET_PRODUCTS,
  GET_BRANDS,
  CREATE_BRAND,
  GET_BRAND_BY_NAME_AND_ID,
  UPDATE_PRODUCT,
} from "./queries";

export const useGetProductsQuery = (variables: any) => {
  const { loading, error, data, refetch } = useQuery(GET_PRODUCTS, {
    variables,
  });

  return { loading, error, data, refetch };
};

export const useGetBrandsQuery = (variables: any) => {
  const { loading, error, data, refetch } = useQuery(GET_BRANDS, {
    variables,
  });

  return { loading, error, data, refetch };
};

export const useCreateBrandMutation = () => {
  const [createBrand, { data, loading, error }] = useMutation(CREATE_BRAND);

  return { createBrand, data, loading, error };
};

export const useGetBrandByNameAndIdQuery = (variables: any) => {
  const { loading, error, data, refetch } = useQuery(GET_BRAND_BY_NAME_AND_ID, {
    variables,
  });

  return { loading, error, data, refetch };
};

export const useUpdateProductMutation = () => {
  const [updateProduct, { data, loading, error }] = useMutation(UPDATE_PRODUCT);

  return { updateProduct, data, loading, error };
};
