| Description                             | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     3.176 μs |  0.0241 μs |  0.0225 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128B         |     7.020 μs |  0.0537 μs |  0.0476 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     1.755 μs |  0.0214 μs |  0.0189 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128B         |     4.972 μs |  0.0193 μs |  0.0181 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |    19.846 μs |  0.1887 μs |  0.1576 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 1KB          |    51.437 μs |  0.1778 μs |  0.1485 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |     9.623 μs |  0.1410 μs |  0.1319 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 1KB          |    36.576 μs |  0.6798 μs |  0.6676 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |   152.820 μs |  1.3735 μs |  1.2847 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 8KB          |   398.635 μs |  1.7178 μs |  1.4344 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |    72.303 μs |  1.4105 μs |  1.3853 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 8KB          |   286.829 μs |  4.5267 μs |  4.2343 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 2,415.871 μs | 26.9480 μs | 25.2072 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128KB        | 6,384.520 μs | 43.5637 μs | 40.7495 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 1,138.633 μs | 10.5020 μs |  9.8236 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128KB        | 4,583.450 μs | 56.3791 μs | 52.7370 μs |         - |