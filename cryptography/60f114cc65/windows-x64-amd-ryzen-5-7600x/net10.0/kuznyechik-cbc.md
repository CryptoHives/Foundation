| Description                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Kuznyechik-CBC (Managed) | 128B         |     422.1 μs |     1.12 μs |     1.00 μs |         - |
|                                    |              |              |             |             |           |
| Encrypt · Kuznyechik-CBC (Managed) | 128B         |     446.9 μs |     2.96 μs |     2.77 μs |         - |
|                                    |              |              |             |             |           |
| Decrypt · Kuznyechik-CBC (Managed) | 1KB          |   3,176.8 μs |    24.90 μs |    22.07 μs |         - |
|                                    |              |              |             |             |           |
| Encrypt · Kuznyechik-CBC (Managed) | 1KB          |   3,154.2 μs |    18.31 μs |    17.13 μs |         - |
|                                    |              |              |             |             |           |
| Decrypt · Kuznyechik-CBC (Managed) | 8KB          |  24,619.7 μs |   153.02 μs |   143.13 μs |         - |
|                                    |              |              |             |             |           |
| Encrypt · Kuznyechik-CBC (Managed) | 8KB          |  25,092.2 μs |    76.86 μs |    71.90 μs |         - |
|                                    |              |              |             |             |           |
| Decrypt · Kuznyechik-CBC (Managed) | 128KB        | 393,420.8 μs | 2,600.17 μs | 2,432.20 μs |         - |
|                                    |              |              |             |             |           |
| Encrypt · Kuznyechik-CBC (Managed) | 128KB        | 394,258.7 μs | 1,502.42 μs | 1,405.36 μs |         - |