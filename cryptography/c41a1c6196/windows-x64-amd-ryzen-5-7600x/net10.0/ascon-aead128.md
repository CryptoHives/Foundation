| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     409.3 ns |   0.91 ns |   0.80 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     532.9 ns |   1.52 ns |   1.35 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     363.2 ns |   0.94 ns |   0.83 ns |     386 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     436.4 ns |   1.42 ns |   1.33 ns |     383 B |      88 B |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,887.1 ns |   3.88 ns |   3.63 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   2,090.4 ns |   6.69 ns |   5.93 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,857.6 ns |   4.80 ns |   4.49 ns |     383 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,966.3 ns |   6.32 ns |   5.60 ns |     383 B |      88 B |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,737.5 ns |  21.90 ns |  18.29 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  14,260.6 ns |  17.76 ns |  14.83 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,536.4 ns |  44.74 ns |  41.85 ns |     386 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  14,193.5 ns |  34.74 ns |  29.01 ns |     383 B |      88 B |
|                                              |              |              |           |           |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 217,519.3 ns | 749.93 ns | 701.48 ns |     306 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 227,177.0 ns | 448.87 ns | 419.87 ns |     306 B |      48 B |
|                                              |              |              |           |           |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 214,346.0 ns | 425.63 ns | 377.31 ns |     383 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 228,849.2 ns | 502.55 ns | 470.08 ns |     383 B |      88 B |