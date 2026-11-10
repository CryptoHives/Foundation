| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     744.0 ns |   1.65 ns |   1.37 ns |     310 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     846.6 ns |   0.63 ns |   0.56 ns |     310 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     650.4 ns |   0.89 ns |   0.84 ns |     387 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     719.1 ns |   1.27 ns |   1.19 ns |     390 B |      88 B |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   3,553.4 ns |   3.14 ns |   2.78 ns |     310 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   3,570.1 ns |   3.98 ns |   3.53 ns |     310 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   3,472.7 ns |   3.89 ns |   3.64 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   3,474.3 ns |   3.73 ns |   3.49 ns |     387 B |         - |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  24,992.9 ns |  23.25 ns |  21.75 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  25,588.6 ns |  36.34 ns |  34.00 ns |     310 B |         - |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  25,138.3 ns |  32.33 ns |  30.24 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  25,597.1 ns |  45.48 ns |  42.54 ns |     387 B |         - |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 395,793.0 ns | 248.72 ns | 220.48 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 406,014.9 ns | 469.43 ns | 439.10 ns |     310 B |         - |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 392,447.5 ns | 417.34 ns | 390.38 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 409,686.5 ns | 740.36 ns | 692.53 ns |     387 B |         - |