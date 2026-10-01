| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     451.3 ns |   1.19 ns |   1.11 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     461.9 ns |   1.05 ns |   0.98 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     378.5 ns |   0.83 ns |   0.74 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     414.5 ns |   1.64 ns |   1.28 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,863.6 ns |   3.76 ns |   3.33 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   2,002.1 ns |   6.62 ns |   5.87 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,824.2 ns |   5.84 ns |   4.88 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,976.9 ns |   5.43 ns |   4.24 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,032.6 ns |  20.13 ns |  18.83 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  14,220.3 ns |  31.38 ns |  29.35 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,599.2 ns |  26.79 ns |  25.06 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  14,461.4 ns | 108.69 ns | 101.67 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 203,501.1 ns | 386.75 ns | 342.84 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 224,308.0 ns | 693.85 ns | 649.03 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 214,566.4 ns | 508.85 ns | 475.98 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 230,803.2 ns | 671.97 ns | 524.63 ns |         - |