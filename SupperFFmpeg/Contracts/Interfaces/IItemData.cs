﻿namespace SupperFFmpeg.Contracts.Interfaces;

public interface IItemData<T>
{
    public T DataBase { get; set; }

    public void SetItemData(T value);
}
