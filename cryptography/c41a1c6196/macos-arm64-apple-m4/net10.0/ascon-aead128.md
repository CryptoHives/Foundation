| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     442.5 ns |   1.06 ns |   0.99 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     445.7 ns |   1.52 ns |   1.35 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     377.6 ns |   0.69 ns |   0.65 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     406.0 ns |   0.75 ns |   0.66 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,827.7 ns |   5.20 ns |   4.86 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,963.0 ns |  16.43 ns |  15.37 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,807.1 ns |   5.07 ns |   4.74 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,943.3 ns |  13.99 ns |  13.08 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  12,703.0 ns |  40.23 ns |  35.66 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,745.4 ns |  53.00 ns |  49.58 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,199.9 ns |  47.56 ns |  44.49 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  14,055.0 ns |  38.86 ns |  34.45 ns |         - |
|                                              |              |              |           |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 201,125.2 ns | 416.15 ns | 347.50 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 220,732.9 ns | 832.61 ns | 778.82 ns |         - |
|                                              |              |              |           |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 209,461.0 ns | 551.69 ns | 516.05 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 223,205.9 ns | 665.60 ns | 622.60 ns |         - |