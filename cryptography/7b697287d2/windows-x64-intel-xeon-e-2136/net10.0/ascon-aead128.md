| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     558.0 ns |     1.42 ns |     1.33 ns |     310 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     632.5 ns |     2.38 ns |     2.11 ns |     310 B |      48 B |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     489.5 ns |     1.68 ns |     1.40 ns |     390 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     541.3 ns |     1.68 ns |     1.57 ns |     387 B |      88 B |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   2,678.5 ns |     7.37 ns |     6.53 ns |     310 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   2,686.7 ns |    10.95 ns |    10.25 ns |     310 B |      48 B |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   2,611.0 ns |     8.52 ns |     7.97 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   2,617.7 ns |     6.15 ns |     5.75 ns |     387 B |         - |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  18,812.0 ns |   163.87 ns |   153.28 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  19,226.4 ns |    61.54 ns |    57.56 ns |     310 B |         - |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  18,799.0 ns |    62.41 ns |    55.32 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  19,240.0 ns |    64.82 ns |    57.46 ns |     387 B |         - |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 296,804.9 ns | 1,120.21 ns |   993.04 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 305,482.5 ns | 1,534.40 ns | 1,360.21 ns |     310 B |         - |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 294,433.0 ns |   820.00 ns |   767.03 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 307,586.5 ns | 1,814.98 ns | 1,608.94 ns |     387 B |         - |