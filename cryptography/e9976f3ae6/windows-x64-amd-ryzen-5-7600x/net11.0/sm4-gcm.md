| Description                            | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |       955.2 ns |     2.03 ns |     1.89 ns |     306 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1,371.9 ns |     6.83 ns |     6.39 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128B         |     1,778.1 ns |    27.65 ns |    25.86 ns |     306 B |     832 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |       909.0 ns |     1.07 ns |     0.95 ns |     386 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1,336.1 ns |     4.66 ns |     4.36 ns |     386 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128B         |     1,660.5 ns |     4.28 ns |     3.58 ns |     386 B |     816 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     6,405.1 ns |    50.35 ns |    47.10 ns |     306 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |     9,185.4 ns |    40.35 ns |    35.77 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 1KB          |     9,502.6 ns |    60.47 ns |    56.56 ns |     306 B |     832 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     6,334.3 ns |    10.34 ns |     9.67 ns |     386 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |     9,133.0 ns |    25.87 ns |    21.60 ns |     386 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 1KB          |     9,279.5 ns |    30.07 ns |    28.13 ns |     386 B |     816 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    50,019.1 ns |   219.11 ns |   204.96 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 8KB          |    70,456.4 ns |   306.71 ns |   286.90 ns |     306 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    73,039.9 ns |   563.36 ns |   526.97 ns |     306 B |         - |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    49,581.1 ns |    52.23 ns |    46.30 ns |     386 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 8KB          |    69,937.7 ns |    71.79 ns |    59.95 ns |     386 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    71,919.7 ns |   243.46 ns |   227.74 ns |     386 B |         - |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   799,649.2 ns | 8,017.67 ns | 6,695.12 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,122,802.9 ns | 4,388.42 ns | 4,104.93 ns |     306 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,159,534.9 ns | 7,241.86 ns | 6,774.04 ns |     306 B |         - |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   792,217.2 ns |   803.91 ns |   671.30 ns |     386 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,113,192.1 ns |   900.61 ns |   842.43 ns |     386 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,143,794.9 ns | 2,332.12 ns | 2,067.37 ns |     386 B |         - |