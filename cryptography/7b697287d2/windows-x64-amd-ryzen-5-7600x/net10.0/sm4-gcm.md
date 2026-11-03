| Description                            | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |       947.6 ns |     0.32 ns |     0.30 ns |     306 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1,385.2 ns |     2.25 ns |     1.99 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128B         |     1,756.2 ns |     1.40 ns |     1.31 ns |     306 B |     832 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |       904.5 ns |     0.43 ns |     0.36 ns |     383 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1,341.1 ns |     1.92 ns |     1.70 ns |     383 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128B         |     1,655.4 ns |     1.88 ns |     1.76 ns |     383 B |     816 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     6,341.1 ns |     3.22 ns |     2.86 ns |     306 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |     9,258.0 ns |     9.93 ns |     8.81 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 1KB          |     9,362.3 ns |     8.62 ns |     7.64 ns |     306 B |     832 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     6,310.7 ns |     2.50 ns |     2.34 ns |     386 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 1KB          |     9,261.8 ns |    10.41 ns |     9.74 ns |     386 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |     9,655.5 ns |    15.27 ns |    13.54 ns |     383 B |         - |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    49,548.9 ns |    32.33 ns |    28.66 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 8KB          |    70,012.9 ns |    51.11 ns |    47.81 ns |     306 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    72,328.0 ns |   143.69 ns |   134.40 ns |     306 B |         - |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    49,485.1 ns |    23.22 ns |    20.58 ns |     383 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 8KB          |    70,080.5 ns |    30.79 ns |    27.29 ns |     383 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    72,380.8 ns |   145.83 ns |   136.41 ns |     383 B |         - |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   790,127.4 ns |   327.86 ns |   306.68 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,112,136.7 ns |   716.59 ns |   670.30 ns |     306 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,152,455.5 ns | 1,024.61 ns |   908.29 ns |     306 B |         - |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   789,858.6 ns |   361.27 ns |   337.93 ns |     383 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,117,040.4 ns |   726.42 ns |   643.95 ns |     383 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,154,292.1 ns | 1,639.22 ns | 1,533.33 ns |     383 B |         - |