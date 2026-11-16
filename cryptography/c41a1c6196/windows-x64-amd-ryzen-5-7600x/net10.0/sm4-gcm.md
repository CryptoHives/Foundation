| Description                            | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |       954.8 ns |     1.51 ns |     1.41 ns |     306 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1,395.8 ns |     2.12 ns |     1.77 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128B         |     1,767.6 ns |     2.29 ns |     1.91 ns |     306 B |     832 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |       908.8 ns |     1.05 ns |     0.88 ns |     383 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1,350.7 ns |     3.49 ns |     3.26 ns |     383 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128B         |     1,660.3 ns |     2.76 ns |     2.44 ns |     383 B |     816 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     6,367.8 ns |     6.04 ns |     5.35 ns |     306 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |     9,324.1 ns |    33.85 ns |    31.66 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 1KB          |     9,416.7 ns |    23.34 ns |    21.83 ns |     306 B |     832 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     6,334.5 ns |     7.04 ns |     6.24 ns |     386 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |     9,287.8 ns |    23.54 ns |    22.02 ns |     383 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 1KB          |     9,311.0 ns |    23.12 ns |    21.63 ns |     383 B |     816 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    49,862.5 ns |    77.74 ns |    64.92 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 8KB          |    70,025.0 ns |    70.72 ns |    66.15 ns |     306 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    72,423.0 ns |   181.52 ns |   160.91 ns |     306 B |         - |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    49,747.5 ns |    63.03 ns |    55.87 ns |     383 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 8KB          |    70,312.0 ns |   100.23 ns |    88.85 ns |     383 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    72,720.6 ns |   241.76 ns |   226.14 ns |     383 B |         - |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   789,751.8 ns |   590.48 ns |   523.44 ns |     306 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,114,321.1 ns | 1,078.55 ns | 1,008.87 ns |     306 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,173,091.0 ns | 2,227.20 ns | 1,974.36 ns |     306 B |         - |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   792,804.4 ns |   532.62 ns |   472.16 ns |     383 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,119,641.7 ns | 1,317.87 ns | 1,232.74 ns |     383 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,159,037.0 ns | 1,912.53 ns | 1,597.05 ns |     383 B |         - |