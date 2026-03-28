| Description                             | TestDataSize | Mean           | Error         | StdDev        | Allocated |
|---------------------------------------- |------------- |---------------:|--------------:|--------------:|----------:|
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |       3.462 μs |     0.0260 μs |     0.0243 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128B         |     400.886 μs |     4.0470 μs |     3.5876 μs |         - |
|                                         |              |                |               |               |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |       1.888 μs |     0.0078 μs |     0.0069 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128B         |     404.735 μs |     1.9351 μs |     1.8101 μs |         - |
|                                         |              |                |               |               |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |      21.909 μs |     0.1145 μs |     0.0956 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 1KB          |   3,479.575 μs |    36.9118 μs |    34.5273 μs |         - |
|                                         |              |                |               |               |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |      10.249 μs |     0.0907 μs |     0.0804 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 1KB          |   3,082.175 μs |    26.3329 μs |    24.6318 μs |         - |
|                                         |              |                |               |               |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |     164.033 μs |     1.0909 μs |     1.0204 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 8KB          |  25,260.490 μs |   171.3379 μs |   160.2695 μs |         - |
|                                         |              |                |               |               |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |      77.407 μs |     0.6801 μs |     0.6361 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 8KB          |  24,372.693 μs |   193.1609 μs |   180.6828 μs |         - |
|                                         |              |                |               |               |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        |   2,609.971 μs |    14.2094 μs |    12.5962 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128KB        | 409,708.836 μs | 3,471.1956 μs | 3,077.1245 μs |         - |
|                                         |              |                |               |               |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        |   1,225.430 μs |     8.3852 μs |     7.4333 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128KB        | 392,286.013 μs | 4,332.4241 μs | 4,052.5522 μs |         - |