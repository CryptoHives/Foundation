| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.437 μs |  0.0057 μs |  0.0050 μs |     310 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     2.417 μs |  0.0209 μs |  0.0186 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128B         |     2.670 μs |  0.0030 μs |  0.0023 μs |     310 B |     832 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.363 μs |  0.0130 μs |  0.0122 μs |     390 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     2.292 μs |  0.0024 μs |  0.0023 μs |     390 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128B         |     2.470 μs |  0.0024 μs |  0.0021 μs |     390 B |     816 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     9.323 μs |  0.0058 μs |  0.0045 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 1KB          |    13.429 μs |  0.0151 μs |  0.0141 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    15.562 μs |  0.1787 μs |  0.1492 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     9.337 μs |  0.0588 μs |  0.0521 μs |     390 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 1KB          |    13.250 μs |  0.0067 μs |  0.0063 μs |     390 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    15.413 μs |  0.0816 μs |  0.0681 μs |     390 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    72.602 μs |  0.4737 μs |  0.3956 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 8KB          |    99.464 μs |  0.0911 μs |  0.0852 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |   120.345 μs |  0.4653 μs |  0.4125 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    73.116 μs |  0.5202 μs |  0.4866 μs |     390 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 8KB          |    99.626 μs |  0.1193 μs |  0.1116 μs |     390 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |   120.420 μs |  1.3924 μs |  1.2343 μs |     390 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        | 1,167.680 μs | 10.0136 μs |  9.3667 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,574.745 μs |  0.1932 μs |  0.1807 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,921.154 μs | 12.8472 μs | 12.0173 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        | 1,157.488 μs |  2.2272 μs |  1.9744 μs |     390 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,581.776 μs |  0.9202 μs |  0.8608 μs |     390 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,930.522 μs | 27.0734 μs | 25.3245 μs |     390 B |         - |