| Description                             | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     2.582 μs |  0.0337 μs |  0.0315 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128B         |     5.638 μs |  0.1123 μs |  0.1715 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     1.448 μs |  0.0054 μs |  0.0048 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128B         |     4.001 μs |  0.0061 μs |  0.0057 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |    15.786 μs |  0.1716 μs |  0.1605 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 1KB          |    39.798 μs |  0.4975 μs |  0.4410 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |     7.571 μs |  0.0310 μs |  0.0259 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 1KB          |    27.749 μs |  0.1922 μs |  0.1798 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |   120.844 μs |  1.7903 μs |  1.6747 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 8KB          |   323.875 μs |  6.1800 μs |  6.8691 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |    56.346 μs |  0.1388 μs |  0.1298 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 8KB          |   216.711 μs |  1.4247 μs |  1.3326 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        | 1,943.832 μs | 27.5328 μs | 25.7542 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128KB        | 5,047.777 μs | 58.2004 μs | 51.5931 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        |   893.556 μs |  2.3709 μs |  2.2177 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128KB        | 3,492.661 μs | 19.4656 μs | 18.2081 μs |         - |