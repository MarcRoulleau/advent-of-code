module AdventOfCode.Workflow

type ProductCode = ProductCode of string

type CheckProductCodeExists = ProductCode -> bool

type UnvalidatedAddress = UnvalidatedAddress of string
type ValidatedAddress = ValidatedAddress of string

type AddressValidationError = AddressValidationError of string

type CheckedAddress = CheckedAddress of UnvalidatedAddress

type UnvalidatedOrder = {
    OrderId : string
    ShippingAddress : UnvalidatedAddress
}

type ValidatedOrder = {
    OrderId : string
    ShippingAddress : ValidatedAddress
}

type PricedOrder = {
    OrderId : string
    ShippingAddress : ValidatedAddress
    Price: int
}

type Order =
    | Unvalidated of UnvalidatedOrder
    | Validated of ValidatedOrder
    | Priced of PricedOrder

type CheckAddressExists = UnvalidatedAddress -> Result<CheckedAddress, AddressValidationError>

type ValidateOrder = CheckProductCodeExists -> CheckAddressExists




