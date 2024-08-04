import { gql } from "@apollo/client";
import { BRAND_FIELDS, TYPE_FIELDS } from "./fragments";

export const GET_PRODUCTS = gql`
  ${BRAND_FIELDS}
  ${TYPE_FIELDS}
  query GetProducts($take: Int, $skip: Int, $order: [ProductSortInput!]) {
    products(take: $take, skip: $skip, order: $order) {
      items {
        id
        name
        brand {
          ...BrandFields
        }
        type {
          ...TypeFields
        }
        price
      }
      totalCount
    }
  }
`;

export const GET_BRANDS = gql`
  query GetBrands($last: Int) {
    brands(last: $last) {
      nodes {
        id
        name
      }
    }
  }
`;

export const CREATE_BRAND = gql`
  mutation CreateBrand($input: CreateBrandInput!) {
    createBrand(input: $input) {
      brand {
        id
        name
      }
    }
  }
`;

export const GET_BRAND_BY_NAME_AND_ID = gql`
  query GetBrandByNameAndId($name: String!, $id: ID!) {
    brandByName(name: $name) {
      name
      id
    }
    brandById(id: $id) {
      name
    }
  }
`;
