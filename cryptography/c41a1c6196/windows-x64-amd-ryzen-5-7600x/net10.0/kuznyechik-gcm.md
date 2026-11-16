| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.204 μs |  0.0033 μs |  0.0030 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     1.671 μs |  0.0046 μs |  0.0041 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.175 μs |  0.0050 μs |  0.0045 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     1.616 μs |  0.0053 μs |  0.0049 μs |     383 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |     8.155 μs |  0.0385 μs |  0.0342 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    11.068 μs |  0.0276 μs |  0.0258 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |     8.234 μs |  0.0206 μs |  0.0183 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    11.090 μs |  0.0417 μs |  0.0390 μs |     383 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    63.838 μs |  0.2226 μs |  0.2082 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |    86.654 μs |  0.2844 μs |  0.2521 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    63.800 μs |  0.3892 μs |  0.3640 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |    86.666 μs |  0.2880 μs |  0.2694 μs |     383 B |         - |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,021.757 μs | 13.7349 μs | 11.4693 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 1,381.287 μs |  2.3363 μs |  2.0710 μs |     306 B |         - |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,016.653 μs |  3.4728 μs |  3.2485 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 1,382.440 μs |  3.2697 μs |  2.8985 μs |     383 B |         - |