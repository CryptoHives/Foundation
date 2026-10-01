| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     406.0 ns |     4.58 ns |     4.28 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     530.0 ns |     6.67 ns |     6.24 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     366.8 ns |     4.89 ns |     4.58 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     444.4 ns |     3.84 ns |     3.59 ns |      88 B |
|                                              |              |              |             |             |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,902.7 ns |    24.13 ns |    22.57 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   2,117.3 ns |    19.71 ns |    18.44 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,869.3 ns |    19.98 ns |    18.69 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,988.5 ns |    21.91 ns |    20.49 ns |      88 B |
|                                              |              |              |             |             |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,918.1 ns |   170.75 ns |   159.72 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  14,445.5 ns |    83.09 ns |    77.72 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,625.5 ns |   118.46 ns |   105.01 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  14,347.1 ns |   171.59 ns |   160.51 ns |      88 B |
|                                              |              |              |             |             |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 219,486.0 ns | 3,412.24 ns | 3,191.81 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 232,367.6 ns | 2,119.73 ns | 1,982.80 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 215,845.1 ns | 2,458.33 ns | 2,299.53 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 231,346.9 ns | 2,903.18 ns | 2,715.64 ns |      88 B |