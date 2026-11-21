| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     434.3 ns |   1.41 ns |   1.18 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     450.9 ns |   0.82 ns |   0.73 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     368.7 ns |   0.93 ns |   0.83 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     405.7 ns |   1.06 ns |   0.94 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,791.8 ns |   6.32 ns |   5.91 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,988.3 ns |   9.47 ns |   8.86 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,776.3 ns |   5.96 ns |   5.58 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,941.0 ns |  13.21 ns |  12.36 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  12,808.8 ns |  41.38 ns |  38.70 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  14,225.3 ns |  28.37 ns |  26.54 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,056.9 ns |  63.28 ns |  59.19 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  14,198.7 ns |  26.19 ns |  24.50 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 202,687.5 ns | 677.44 ns | 633.68 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 224,071.6 ns | 680.38 ns | 603.14 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 206,955.8 ns | 576.03 ns | 538.82 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 224,077.2 ns | 478.02 ns | 447.14 ns |         - |