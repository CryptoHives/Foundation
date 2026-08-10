| Description                           | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-128-CBC (Managed)      | 128B         |     2.459 μs |  0.0154 μs |  0.0137 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.510 μs |  0.0138 μs |  0.0122 μs |    1288 B |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.365 μs |  0.0143 μs |  0.0127 μs |    1288 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128B         |     2.457 μs |  0.0168 μs |  0.0157 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    15.149 μs |  0.0881 μs |  0.0824 μs |    3528 B |
| Decrypt · ARIA-128-CBC (Managed)      | 1KB          |    17.522 μs |  0.0985 μs |  0.0873 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    15.236 μs |  0.0386 μs |  0.0361 μs |    3528 B |
| Encrypt · ARIA-128-CBC (Managed)      | 1KB          |    17.613 μs |  0.0665 μs |  0.0589 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   117.925 μs |  0.4366 μs |  0.4084 μs |   21448 B |
| Decrypt · ARIA-128-CBC (Managed)      | 8KB          |   139.103 μs |  0.7738 μs |  0.6041 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   118.227 μs |  0.3643 μs |  0.3408 μs |   21448 B |
| Encrypt · ARIA-128-CBC (Managed)      | 8KB          |   141.831 μs |  0.5494 μs |  0.5139 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,860.208 μs |  6.3719 μs |  5.6485 μs |  328648 B |
| Decrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,208.236 μs | 16.8325 μs | 15.7452 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,879.186 μs |  6.4646 μs |  6.0470 μs |  328648 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,218.603 μs | 15.6937 μs | 14.6799 μs |         - |