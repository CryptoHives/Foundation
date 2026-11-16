| Description                                   | TestDataSize | Mean         | Error      | StdDev      | Median       | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|------------:|-------------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     2.102 μs |  0.0042 μs |   0.0073 μs |     2.099 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     3.158 μs |  0.0089 μs |   0.0167 μs |     3.155 μs |     310 B |         - |
|                                               |              |              |            |             |              |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     2.143 μs |  0.0951 μs |   0.1714 μs |     2.025 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     3.309 μs |  0.0976 μs |   0.1710 μs |     3.412 μs |     390 B |         - |
|                                               |              |              |            |             |              |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    16.533 μs |  0.0425 μs |   0.0767 μs |    16.518 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    23.863 μs |  0.0632 μs |   0.1156 μs |    23.838 μs |     310 B |         - |
|                                               |              |              |            |             |              |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |    16.460 μs |  0.0527 μs |   0.0991 μs |    16.401 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    23.814 μs |  0.0710 μs |   0.1350 μs |    23.783 μs |     387 B |         - |
|                                               |              |              |            |             |              |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |   108.703 μs |  0.3607 μs |   0.6862 μs |   108.548 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   166.001 μs |  0.6634 μs |   1.2296 μs |   165.662 μs |     310 B |         - |
|                                               |              |              |            |             |              |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |   122.756 μs |  5.2894 μs |   9.8042 μs |   128.535 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |   186.330 μs |  0.5111 μs |   0.9474 μs |   186.213 μs |     387 B |         - |
|                                               |              |              |            |             |              |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,730.505 μs |  4.5620 μs |   8.3419 μs | 1,728.097 μs |     310 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 2,739.494 μs | 79.3053 μs | 143.0039 μs | 2,657.111 μs |     310 B |         - |
|                                               |              |              |            |             |              |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,948.470 μs | 82.1300 μs | 156.2610 μs | 2,048.740 μs |     387 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 2,975.878 μs |  8.4564 μs |  16.0891 μs | 2,976.502 μs |     387 B |         - |