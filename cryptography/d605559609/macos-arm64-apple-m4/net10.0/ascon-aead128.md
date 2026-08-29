| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Median       | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     445.6 ns |   0.05 ns |   0.05 ns |     445.6 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     445.9 ns |   3.44 ns |   8.56 ns |     442.2 ns |      48 B |
|                                              |              |              |           |           |              |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     376.3 ns |   0.16 ns |   0.15 ns |     376.3 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     411.3 ns |   0.12 ns |   0.09 ns |     411.3 ns |         - |
|                                              |              |              |           |           |              |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,827.0 ns |   0.24 ns |   0.21 ns |   1,827.0 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,938.6 ns |   2.20 ns |   1.84 ns |   1,938.3 ns |         - |
|                                              |              |              |           |           |              |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,811.7 ns |   0.62 ns |   0.55 ns |   1,811.8 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,963.4 ns |   0.39 ns |   0.34 ns |   1,963.5 ns |         - |
|                                              |              |              |           |           |              |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  12,764.8 ns |  12.61 ns |  11.18 ns |  12,758.4 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,931.1 ns |   1.58 ns |   1.40 ns |  13,931.1 ns |         - |
|                                              |              |              |           |           |              |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,325.6 ns |  33.33 ns |  29.55 ns |  13,316.7 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  14,249.8 ns |   1.84 ns |   1.53 ns |  14,249.6 ns |         - |
|                                              |              |              |           |           |              |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 202,176.1 ns | 372.79 ns | 330.47 ns | 202,010.2 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 221,462.5 ns | 152.39 ns | 142.55 ns | 221,505.2 ns |         - |
|                                              |              |              |           |           |              |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 210,774.4 ns |  97.16 ns |  81.14 ns | 210,787.7 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 225,316.3 ns |  57.09 ns |  47.67 ns | 225,310.3 ns |         - |