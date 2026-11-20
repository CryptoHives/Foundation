| Description                                  | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     408.5 ns |     0.88 ns |   0.69 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     491.6 ns |     1.35 ns |   1.20 ns |     306 B |      48 B |
|                                              |              |              |             |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     363.9 ns |     4.90 ns |   4.09 ns |     386 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     417.9 ns |     3.30 ns |   2.58 ns |     386 B |      88 B |
|                                              |              |              |             |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,875.9 ns |     3.19 ns |   2.49 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,954.3 ns |     2.97 ns |   2.48 ns |     306 B |      48 B |
|                                              |              |              |             |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,814.8 ns |     2.15 ns |   1.68 ns |     386 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,847.6 ns |     4.09 ns |   3.63 ns |     386 B |      88 B |
|                                              |              |              |             |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,426.5 ns |    17.60 ns |  14.69 ns |     306 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,647.1 ns |    25.46 ns |  21.26 ns |     306 B |         - |
|                                              |              |              |             |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,326.5 ns |    28.66 ns |  22.38 ns |     386 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,371.5 ns |    27.99 ns |  21.85 ns |     386 B |         - |
|                                              |              |              |             |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 213,982.6 ns |   279.46 ns | 233.36 ns |     306 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 216,373.0 ns | 1,021.36 ns | 955.38 ns |     306 B |         - |
|                                              |              |              |             |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 211,519.1 ns |   309.08 ns | 258.10 ns |     386 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 215,903.4 ns |   365.96 ns | 324.41 ns |     386 B |      88 B |