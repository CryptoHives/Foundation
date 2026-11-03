| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     410.8 ns |   0.99 ns |   0.88 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     527.7 ns |   1.54 ns |   1.44 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     362.0 ns |   0.78 ns |   0.69 ns |     386 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     435.8 ns |   0.69 ns |   0.61 ns |     383 B |      88 B |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,892.3 ns |   3.02 ns |   2.52 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   2,089.8 ns |  10.19 ns |   9.53 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,819.8 ns |   3.81 ns |   3.56 ns |     383 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,972.8 ns |   7.21 ns |   6.74 ns |     383 B |      88 B |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,777.1 ns |  27.13 ns |  22.65 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  14,321.6 ns |  21.44 ns |  20.06 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,489.8 ns |  30.55 ns |  28.58 ns |     386 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  14,181.8 ns |  20.23 ns |  18.92 ns |     383 B |      88 B |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 217,806.5 ns | 440.36 ns | 411.91 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 227,715.8 ns | 588.18 ns | 550.18 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 214,919.9 ns | 617.83 ns | 577.92 ns |     383 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 229,525.3 ns | 437.86 ns | 409.57 ns |     383 B |      88 B |