import { gql } from "@apollo/client";

export const BRAND_FIELDS = gql`
  fragment BrandFields on Brand {
    id
    name
  }
`;

export const TYPE_FIELDS = gql`
  fragment TypeFields on ProductType {
    id
    name
  }
`;
