| Description                             | TestDataSize | Mean         | Error      | StdDev     | Median       | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|-------------:|----------:|
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     2.369 μs |  0.0178 μs |  0.0157 μs |     2.368 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128B         |     5.488 μs |  0.2122 μs |  0.6189 μs |     5.132 μs |         - |
|                                         |              |              |            |            |              |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     1.354 μs |  0.0115 μs |  0.0107 μs |     1.349 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128B         |     3.639 μs |  0.0252 μs |  0.0235 μs |     3.632 μs |         - |
|                                         |              |              |            |            |              |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |    14.476 μs |  0.0449 μs |  0.0398 μs |    14.481 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 1KB          |    36.766 μs |  0.4178 μs |  0.3703 μs |    36.699 μs |         - |
|                                         |              |              |            |            |              |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |     7.103 μs |  0.0291 μs |  0.0272 μs |     7.097 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 1KB          |    25.812 μs |  0.2202 μs |  0.1839 μs |    25.763 μs |         - |
|                                         |              |              |            |            |              |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |   111.100 μs |  0.5951 μs |  0.5276 μs |   111.134 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 8KB          |   290.177 μs |  5.0781 μs |  4.2404 μs |   288.838 μs |         - |
|                                         |              |              |            |            |              |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |    53.127 μs |  0.1171 μs |  0.0914 μs |    53.123 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 8KB          |   204.811 μs |  0.9689 μs |  0.9063 μs |   205.040 μs |         - |
|                                         |              |              |            |            |              |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        | 1,767.105 μs |  7.8825 μs |  6.9876 μs | 1,768.490 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128KB        | 4,657.824 μs | 83.0645 μs | 73.6345 μs | 4,636.716 μs |         - |
|                                         |              |              |            |            |              |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        |   840.009 μs |  1.8007 μs |  1.5963 μs |   839.507 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128KB        | 3,251.113 μs | 18.1071 μs | 16.9374 μs | 3,252.092 μs |         - |