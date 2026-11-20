| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     745.3 ns |     1.54 ns |     1.44 ns |     310 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     810.6 ns |     1.22 ns |     1.08 ns |     310 B |      48 B |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     652.6 ns |     2.14 ns |     1.79 ns |     390 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     693.1 ns |     0.68 ns |     0.60 ns |     390 B |      88 B |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   3,378.6 ns |     9.79 ns |     9.16 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   3,561.6 ns |     6.25 ns |     5.22 ns |     310 B |         - |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   3,322.1 ns |    32.40 ns |    30.30 ns |     390 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   3,553.7 ns |    57.37 ns |    80.43 ns |     390 B |         - |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  23,663.5 ns |    36.70 ns |    34.32 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  25,583.6 ns |    53.94 ns |    50.45 ns |     310 B |         - |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  23,531.0 ns |    49.70 ns |    44.06 ns |     390 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  25,643.8 ns |   129.20 ns |   120.85 ns |     390 B |         - |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 374,405.1 ns |   584.01 ns |   546.28 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 406,416.8 ns |   936.13 ns |   829.85 ns |     310 B |         - |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 369,745.4 ns |   558.37 ns |   466.26 ns |     390 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 410,185.0 ns | 1,460.84 ns | 1,366.47 ns |     390 B |         - |