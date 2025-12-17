# Whirlpool Test Vectors

## Overview

Whirlpool is a cryptographic hash function designed by Vincent Rijmen and
Paulo S. L. M. Barreto. It produces a 512-bit hash value and is based on
a modified AES-like block cipher.

## Specification

- **Standard:** ISO/IEC 10118-3:2004
- **Output Size:** 512 bits (64 bytes)
- **Block Size:** 512 bits (64 bytes)
- **Rounds:** 10
- **State Size:** 8×8 bytes (64 bytes)

This implementation uses Whirlpool 3.0 (the final, standardized version).

## Official Reference

- ISO/IEC 10118-3:2004
- NESSIE project: https://www.cosic.esat.kuleuven.be/nessie/
- Original paper: "The Whirlpool Hashing Function"
- https://www.larc.usp.br/~pbarreto/WhirlpoolPage.html

## Test Vectors

### Vector 1: Empty string

```
Input:  "" (empty)
Length: 0 bytes

Output: 19FA61D75522A4669B44E39C1D2E1726C530232130D407F89AFEE0964997F7A7
        3E83BE698B288FEBCF88E3E03C4F0757EA8964E59B63D93708B138CC42A66EB3
```

### Vector 2: Single character "a"

```
Input:  "a"
Length: 1 byte
Hex:    61

Output: 8ACA2602792AEC6F11A67206531FB7D7F0DFF59413145E6973C45001D0087B42
        D11BC645413AEFF63A42391A39145A591A92200D560195E53B478584FDAE231A
```

### Vector 3: "abc"

```
Input:  "abc"
Length: 3 bytes
Hex:    616263

Output: 4E2448A4C6F486BB16B6562C73B4020BF3043E3A731BCE721AE1B303D97E6D4C
        7181EEBDB6C57E277D0E34957114CBD6C797FC9D95D8B582D225292076D4EEF5
```

### Vector 4: "message digest"

```
Input:  "message digest"
Length: 14 bytes

Output: 378C84A4126E2DC6E56DCC7458377AAC838D00032230F53CE1F5700C0FFB4D3B
        8421557659EF55C106B4B52AC5A4AAA692ED920052838F3362E86DBD37A8903E
```

### Vector 5: Lowercase alphabet

```
Input:  "abcdefghijklmnopqrstuvwxyz"
Length: 26 bytes

Output: F1D754662636FFE92C82EBB9212A484A8D38631EAD4238F5442EE13B8054E41B
        08BF2A9251C30B6A0B8AAE86177AB4A6F68F673E7207865D5D9819A3DBA4EB3B
```

### Vector 6: Full alphanumeric

```
Input:  "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
Length: 62 bytes

Output: DC37E008CF9EE69BF11F00ED9ABA26901DD7C28CDEC066CC6AF42E40F82F3A1E
        08EBA26629129D8FB7CB57211B9281A65517CC879D7B962142C65F5A7AF01467
```

### Vector 7: Extended numeric

```
Input:  "12345678901234567890123456789012345678901234567890123456789012345678901234567890"
Length: 80 bytes

Output: 466EF18BABB0154D25B9D38A6414F5C08784372BCCB204D6549C4AFADB601429
        4D5BD8DF2A6C44E538CD047B2681A51A2C60481E88C5A20B2C2A80CF3A9A083B
```

### Vector 8: "The quick brown fox..."

```
Input:  "The quick brown fox jumps over the lazy dog"
Length: 43 bytes

Output: B97DE512E91E3828B40D2B0FDCE9CEB3C4A71F9BEA8D88E75C4FA854DF36725F
        D2B52EB6544EDCACD6F8BEDDFEA403CB55AE31F03AD62A5EF54E42EE82C3FB35
```

### Vector 9: Million "a" characters

```
Input:  "a" repeated 1,000,000 times
Length: 1,000,000 bytes

Output: 0C99005BEB57EFF50A7CF005560DDF5D29057FD86B20BFD62DECA0F1CCEA4AF5
        1FC15490EDDC47AF32BB2B66C34FF9AD8C6008AD677F77126953B226E4ED8B01
```

## Algorithm Details

### Structure

- Uses Miyaguchi-Preneel compression function
- 10 rounds per block
- 8×8 byte state matrix
- AES-like operations: SubBytes, ShiftColumns, MixRows, AddRoundKey

### S-box

The S-box is derived from the composition of:
- Multiplicative inverse in GF(2^8)
- Affine transformation

### MDS Matrix

The MDS (Maximum Distance Separable) matrix uses elements from GF(2^8)
with reduction polynomial x^8 + x^4 + x^3 + x^2 + 1.

### Round Constants

Round constants are derived from the S-box applied to sequential indices.

## Implementation Notes

- Uses big-endian byte order
- 256-bit message length counter (supports very large messages)
- State organized as 8×8 byte matrix (columns = state words)
- Cyclical shift pattern different from AES
