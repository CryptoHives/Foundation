| Description                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (Managed) | 128B         |     384.4 μs |   7.64 μs |  10.95 μs |         - |
|                                    |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (Managed) | 128B         |     377.6 μs |   7.01 μs |   6.22 μs |         - |
|                                    |              |              |           |           |           |
| Decrypt · Kuznyechik-CBC (Managed) | 1KB          |   3,181.6 μs |  12.86 μs |  12.03 μs |         - |
|                                    |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (Managed) | 1KB          |   2,957.0 μs |  20.45 μs |  18.13 μs |         - |
|                                    |              |              |           |           |           |
| Decrypt · Kuznyechik-CBC (Managed) | 8KB          |  26,392.5 μs |  41.45 μs |  38.77 μs |         - |
|                                    |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (Managed) | 8KB          |  25,439.2 μs |  29.89 μs |  26.50 μs |         - |
|                                    |              |              |           |           |           |
| Decrypt · Kuznyechik-CBC (Managed) | 128KB        | 412,074.8 μs | 732.89 μs | 685.54 μs |         - |
|                                    |              |              |           |           |           |
| Encrypt · Kuznyechik-CBC (Managed) | 128KB        | 404,593.0 μs | 472.23 μs | 418.62 μs |         - |