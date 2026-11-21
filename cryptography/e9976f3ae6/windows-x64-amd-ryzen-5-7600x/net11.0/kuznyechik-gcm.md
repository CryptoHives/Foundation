| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.238 μs |  0.0206 μs |  0.0192 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     1.643 μs |  0.0173 μs |  0.0144 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.180 μs |  0.0144 μs |  0.0135 μs |     386 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     1.612 μs |  0.0149 μs |  0.0139 μs |     386 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |     8.194 μs |  0.1044 μs |  0.0872 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    11.025 μs |  0.0338 μs |  0.0316 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |     8.219 μs |  0.0631 μs |  0.0527 μs |     386 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    11.046 μs |  0.0884 μs |  0.0827 μs |     386 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    63.796 μs |  0.2834 μs |  0.2512 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |    85.655 μs |  0.3761 μs |  0.3518 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    64.543 μs |  0.7914 μs |  0.7403 μs |     386 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |    86.610 μs |  0.8344 μs |  0.7805 μs |     386 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,014.650 μs |  5.3779 μs |  4.4908 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 1,367.762 μs |  9.7349 μs |  8.1291 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,030.557 μs | 10.9381 μs |  9.6963 μs |     386 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 1,386.261 μs | 18.1822 μs | 16.1180 μs |     386 B |         - |