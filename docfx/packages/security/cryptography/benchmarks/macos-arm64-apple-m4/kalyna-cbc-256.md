| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (Managed)      | 128B         |     3.093 μs | 0.0005 μs | 0.0004 μs |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     3.297 μs | 0.0014 μs | 0.0012 μs |    1112 B |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     1.700 μs | 0.0010 μs | 0.0009 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128B         |     2.783 μs | 0.0016 μs | 0.0014 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |    21.142 μs | 0.0097 μs | 0.0091 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 1KB          |    22.297 μs | 0.0074 μs | 0.0069 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |     9.726 μs | 0.0279 μs | 0.0261 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 1KB          |    20.007 μs | 0.0802 μs | 0.0750 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |   163.885 μs | 0.0589 μs | 0.0522 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 8KB          |   175.610 μs | 0.0309 μs | 0.0258 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |    73.721 μs | 0.2058 μs | 0.1925 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 8KB          |   157.195 μs | 0.4980 μs | 0.4658 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 2,611.970 μs | 1.9011 μs | 1.6853 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128KB        | 2,807.504 μs | 0.8380 μs | 0.7428 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 1,171.964 μs | 3.8163 μs | 3.5697 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128KB        | 2,516.454 μs | 1.3460 μs | 1.2591 μs |         - |